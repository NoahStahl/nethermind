//  Copyright (c) 2018 Demerzel Solutions Limited
//  This file is part of the Nethermind library.
// 
//  The Nethermind library is free software: you can redistribute it and/or modify
//  it under the terms of the GNU Lesser General Public License as published by
//  the Free Software Foundation, either version 3 of the License, or
//  (at your option) any later version.
// 
//  The Nethermind library is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY; without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the
//  GNU Lesser General Public License for more details.
// 
//  You should have received a copy of the GNU Lesser General Public License
//  along with the Nethermind. If not, see <http://www.gnu.org/licenses/>.

using Nethermind.Core;
using Nethermind.Core.Crypto;
using Nethermind.JsonRpc;
using Nethermind.JsonRpc.Modules;

namespace Nethermind.Consensus.Clique
{
    [RpcModule(ModuleType.Clique)]
    public interface ICliqueModule : IModule
    {
        [JsonRpcMethod(Description = "Retrieves a snapshot of all clique state at a given block.", Returns = "Object", IsImplemented = true)]
        ResultWrapper<Snapshot> clique_getSnapshot();

        [JsonRpcMethod(Description = "Retrieves the state snapshot at a given block.", Returns = "Object", IsImplemented = true)]
        ResultWrapper<Snapshot> clique_getSnapshotAtHash(Keccak hash);

        [JsonRpcMethod(Description = "Retrieves the list of authorized signers.", Returns = "Array", IsImplemented = true)]
        ResultWrapper<Address[]> clique_getSigners();

        [JsonRpcMethod(Description = "Retrieves the list of authorized signers at the specified block by hash.", Returns = "Array", IsImplemented = true)]
        ResultWrapper<Address[]> clique_getSignersAtHash(Keccak hash);

        [JsonRpcMethod(Description = "Retrieves the list of authorized signers at the specified block by block number.", Returns = "Array", IsImplemented = true)]
        ResultWrapper<Address[]> clique_getSignersAtNumber(long number);

        [JsonRpcMethod(Description = "", Returns = "Array", IsImplemented = true)]
        ResultWrapper<string[]> clique_getSignersAnnotated();

        [JsonRpcMethod(Description = "", Returns = "Array", IsImplemented = true)]
        ResultWrapper<string[]> clique_getSignersAtHashAnnotated(Keccak hash);

        [JsonRpcMethod(Description = "Adds a new authorization proposal that the signer will attempt to push through. If the `vote` parameter is true, the local signer votes for the given address to be included in the set of authorized signers. With `vote` set to false, the signer is against the address.", Returns = "Boolean", IsImplemented = true)]
        ResultWrapper<bool> clique_propose(Address signer, bool vote);

        [JsonRpcMethod(Description = "This method drops a currently running proposal. The signer will not cast further votes (either for or against) the address.", Returns = "Boolean", IsImplemented = true)]
        ResultWrapper<bool> clique_discard(Address signer);

        [JsonRpcMethod(Description = "", Returns = "Boolean", IsImplemented = true)]
        ResultWrapper<bool> clique_produceBlock(Keccak parentHash);
    }
}