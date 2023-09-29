using Plugin.Core;
using Plugin.Example1.Models;

namespace Plugin.Example1;

/// <summary>
/// Marker interface for agegating common repository interfaces.
/// </summary>
public interface IStandardRepository :
    IGetAll<ClientAddress> ,
    IGetById<ClientAddress>,
    IUpdate<ClientAddress>,
    IDelete<ClientAddress>,
    IInsert<ClientAddress>
{

}
