using System.Linq;
using AutoMapper;
using HospitalAPI.DTOs.MappingProfile;
using HospitalClassLibrary.Data;
using HospitalClassLibrary.GraphicalEditor.Repositories;
using HospitalClassLibrary.GraphicalEditor.Repositories.Interfaces;
using HospitalClassLibrary.GraphicalEditor.Services;
using HospitalClassLibrary.GraphicalEditor.Services.Interfaces;
using HospitalClassLibrary.RoomEquipment.Repositories;
using HospitalClassLibrary.RoomEquipment.Repositories.Interfaces;
using HospitalClassLibrary.RoomEquipment.Services;
using HospitalClassLibrary.RoomEquipment.Services.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

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

            services.AddDbContext<AppDbContext>(options =>
                options.UseNpgsql(Configuration.GetConnectionString("APIConnection"))
            );
            services.AddTransient<IRoomRepository, RoomRepository>();
            services.AddTransient<IBuildingRepository, BuildingRepository>();
            services.AddTransient<IEquipmentRepository, EquipmentRepository>();

            services.AddTransient<IBuildingService, BuildingService>();
            services.AddTransient<IRoomService, RoomService>();
            services.AddTransient<IEquipmentService, EquipmentService>();

            services.AddCors();

            var mapperConfig = new MapperConfiguration(mc => { mc.AddProfile(new MappingProfile()); });

            IMapper mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);

            services.AddAutoMapper(config =>
            {
                var enumMapper = config.Mappers.Single(m => m is AutoMapper.Mappers.EnumToEnumMapper);
                config.Mappers.Remove(enumMapper);
            }, typeof(Startup));
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

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
