using System.Threading.Tasks;
using PlatformServices.DTOs;

namespace PlatformServices.SyncDataServices.Http
{
    public interface ICommandDataClient
    {
        Task SendPlatformToCommand(PlatformReadDto plat);
    }
}
