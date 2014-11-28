namespace QRInfoSystem.Web.ViewModels
{
    using AutoMapper;
    using QRInfoSystem.Models;
    using QRInfoSystem.Web.Infrastructure.Mapping;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Web;
    public class SheduleViewModel : IHaveCustomMappings
    {
        public int Id { get; set; }

        [Required]
        public DateTime StartDate { get; set; }

        [Required]
        public DateTime EndDate { get; set; }

        public int TeacherId { get; set; }
        
        [StringLength(4,MinimumLength=4)]
        [Required]
        public string RoomName { get; set; }

        public void CreateMappings(AutoMapper.IConfiguration configuration)
        {
            configuration.CreateMap<Shedule, SheduleViewModel>()
               .ForMember(s => s.RoomName, opt =>
                   opt.MapFrom(r => r.Room.Model));
            configuration.CreateMap<SheduleViewModel,Shedule >()
                .ForMember(s => s.RoomId, opt =>
                    opt.MapFrom(r => r.RoomName));
        }
    }
}