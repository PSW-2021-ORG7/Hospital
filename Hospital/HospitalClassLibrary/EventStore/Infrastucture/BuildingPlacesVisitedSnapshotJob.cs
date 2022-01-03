using HospitalClassLibrary.Data;
using HospitalClassLibrary.EventStore.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace HospitalClassLibrary.EventStore.Infrastucture
{
    class BuildingPlacesVisitedSnapshotJob
    {
        private readonly AppDbContext db;

        public BuildingPlacesVisitedSnapshotJob(AppDbContext db)
        {
            this.db = db;
        }

        //public void Run()
        //{
        //    while (true)
        //    {
        //        foreach (var id in GetIds())
        //        {
        //            using (var session = documentStore.OpenSession())
        //            {
        //                var repository = new BuildingPlcaesVisitedRepository(new Repositories.EventStore(session));
        //                var account = repository.FindBy(id);
        //                var snapshot = account.GetBuildingPlacesVisitedSnapshot();
        //                repository.SaveSnapshot(snapshot, account);
        //            }
        //        }

        //        // Create a new snapshot for each Aggregate every 12 hours
        //        Thread.Sleep(TimeSpan.FromHours(12));
        //    }
        //}

        //private IEnumerable<int> GetIds()
        //{
        //    using (var session = documentStore.OpenSession())
        //    {
        //        return session.Query<EventStream>()
        //                      .Select(x => x.Id)
        //                      .ToList();
        //    }
        //}
    }
}
