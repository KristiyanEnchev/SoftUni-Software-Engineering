namespace FootballManager.Services
{
    using AutoMapper;
    using FootballManager.Data.Models;
    using FootballManager.ViewModels.Players;
    using System;

    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            this.CreateMap<Player, AllPlayersViewModel>();
            this.CreateMap<Player, UserCollectionViewModel>();
        }
    }
}
