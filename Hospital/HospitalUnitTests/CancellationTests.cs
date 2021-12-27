using System;
using System.Collections.Generic;
using HospitalClassLibrary.Renovations.Models;
using HospitalClassLibrary.RoomEquipment.Models;
using HospitalClassLibrary.Shared.Services;
using Shouldly;
using Xunit;

namespace HospitalUnitTests
{
    public class CancellationTests
    {
        [Theory]
        [MemberData(nameof(EquipmentTransferData))]
        public void Checks_if_equipment_transfer_can_be_cancelled(EquipmentTransfer equipmentTransfer, bool result)
        {
            var service = new CancellationService();

            var canBeCancelled = service.CanBeCancelled(equipmentTransfer.TransferDate);

            canBeCancelled.Result.ShouldBe(result);
        }

        [Theory]
        [MemberData(nameof(RoomRenovationData))]
        public void Checks_if_room_renovation_can_be_cancelled(MergeRenovation mergeRenovation, bool result)
        {
            var service = new CancellationService();

            var canBeCancelled = service.CanBeCancelled(mergeRenovation.Start);

            canBeCancelled.Result.ShouldBe(result);
        }

        public static IEnumerable<object[]> EquipmentTransferData()
        {
            var retVal = new List<object[]>
            {
                new object[]
            {
                new EquipmentTransfer()
                {
                    TransferDate = new DateTime(2021, 12, 26)
                },
                false
            },

                new object[] 
            {
                new EquipmentTransfer()
                {
                    TransferDate = new DateTime(2022, 5, 24)
                },
                true
            }
            };

            return retVal;
        }
        public static IEnumerable<object[]> RoomRenovationData()
        {
            var retVal = new List<object[]>
            {
                new object[]
                {
                    new MergeRenovation()
                    {
                        Start = new DateTime(2021, 12, 26)
                    },
                    false
                },

                new object[]
                {
                    new MergeRenovation()
                    {
                        Start = new DateTime(2022, 5, 24)
                    },
                    true
                }
            };

            return retVal;
        }
    }
}
