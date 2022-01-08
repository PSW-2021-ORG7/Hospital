using System.Linq;
using AutoMapper;
using HospitalAPI.DTOs.MappingProfile;
using HospitalAPI.HostedServices;
using HospitalClassLibrary.Data;
using HospitalClassLibrary.GraphicalEditor.Repositories;
using HospitalClassLibrary.GraphicalEditor.Repositories.Interfaces;
using HospitalClassLibrary.GraphicalEditor.Services;
using HospitalClassLibrary.GraphicalEditor.Services.Interfaces;
using HospitalClassLibrary.Renovations.Repositories;
using HospitalClassLibrary.Renovations.Repositories.Interfaces;
using HospitalClassLibrary.Renovations.Services;
using HospitalClassLibrary.Renovations.Services.Interfaces;
using HospitalClassLibrary.RoomEquipment.Repositories;
using HospitalClassLibrary.RoomEquipment.Repositories.Interfaces;
using HospitalClassLibrary.RoomEquipment.Services;
using HospitalClassLibrary.RoomEquipment.Services.Interfaces;
using HospitalClassLibrary.Schedule.Repositories;
using HospitalClassLibrary.Schedule.Repositories.Interfaces;
using HospitalClassLibrary.Schedule.Services;
using HospitalClassLibrary.Schedule.Services.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using HospitalClassLibrary.Shared.Services;
using HospitalClassLibrary.Shared.Services.Interfaces;
using HospitalClassLibrary.Events.EventBuildingSelection;
using HospitalClassLibrary.Events.EventEquipmentTransfer;
using HospitalClassLibrary.Events.EventRoomSelection;
using HospitalClassLibrary.Events.LogEvent;

namespace HospitalAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            string connectionString = Environment.GetEnvironmentVariable("DB_CONNECTION_STRING_H");
            if (connectionString == null) connectionString = Configuration.GetConnectionString("APIConnection");
            services.AddDbContext<AppDbContext>(options =>
                options.UseNpgsql(connectionString, providerOptions => providerOptions.EnableRetryOnFailure())
            );

            RegisterRepositories(services);

            RegisterServices(services);

            ConfigureMapper(services);

            services.AddCors();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseCors(options => options.WithOrigins("http://localhost:4200")
                .AllowAnyMethod()
                .AllowAnyHeader());

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }

        private static void RegisterServices(IServiceCollection services)
        {
            services.AddTransient<IBuildingService, BuildingService>();
            services.AddTransient<IRoomService, RoomService>();
            services.AddTransient<IEquipmentService, EquipmentService>();
            services.AddTransient<IWorkdayService, WorkdayService>();
            services.AddTransient<IEquipmentTransferService, EquipmentTransferService>();
            services.AddTransient<IRenovationService, RenovationService>();
            services.AddHostedService<TransfersHostedService>();
            services.AddScoped<ITransferCheckerService, TransferCheckerService>();
            services.AddHostedService<RenovationsHostedService>();
            services.AddScoped<IRenovationCheckerService, RenovationCheckerService>();
            services.AddScoped<ICancellationService, CancellationService>();
            services.AddScoped<IShiftService, ShiftService>();
            //Events
            services.AddScoped<ILogEventService<BuildingSelectionEventParams>, BuildingSelectionEventService>();
            services.AddScoped<ILogEventService<RoomSelectionEventParams>, RoomSelectionEventService>();
            services.AddScoped<ILogEventService<EquipmentTransferEventParams>, EquipmentTransferEventService>();
        }

        private static void RegisterRepositories(IServiceCollection services)
        {
            services.AddTransient<IRoomRepository, RoomRepository>();
            services.AddTransient<IBuildingRepository, BuildingRepository>();
            services.AddTransient<IEquipmentRepository, EquipmentRepository>();
            services.AddTransient<IWorkdayRepository, WorkdayRepository>();
            services.AddTransient<IEquipmentTransferRepository, EquipmentTransferRepository>();
            services.AddTransient<ISplitRenovationRepository, SplitRenovationRepository>();
            services.AddTransient<IMergeRenovationRepository, MergeRenovationRepository>();
            services.AddTransient<IDoctorRepository, DoctorRepository>();
            services.AddTransient<IShiftRepository, ShiftRepository>();
            //Events
            services.AddTransient<IBuildingSelectionEventRepository, BuildingSelectionEventDatabase>();
            services.AddTransient<IEquipmentTransferEventRepository, EquipmentTransferEventDatabase>();
            services.AddTransient<IRoomSelectionEventRepository, RoomSelectionEventDatabase>();
        }

        private static void ConfigureMapper(IServiceCollection services)
        {
            var mapperConfig = new MapperConfiguration(mc => { mc.AddProfile(new MappingProfile()); });

            IMapper mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);

            services.AddAutoMapper(config =>
            {
                var enumMapper = config.Mappers.Single(m => m is AutoMapper.Mappers.EnumToEnumMapper);
                config.Mappers.Remove(enumMapper);
            }, typeof(Startup));
        }
    }
}