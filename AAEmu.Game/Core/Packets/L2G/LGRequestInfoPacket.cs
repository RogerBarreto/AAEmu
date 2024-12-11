﻿using AAEmu.Commons.Network;
using AAEmu.Game.Core.Managers.UnitManagers;
using AAEmu.Game.Core.Network.Login;
using AAEmu.Game.Core.Packets.G2L;

namespace AAEmu.Game.Core.Packets.L2G;

public class LGRequestInfoPacket : LoginPacket
{
    public LGRequestInfoPacket() : base(LGOffsets.LGRequestInfoPacket)
    {
    }

    public override void Read(PacketStream stream)
    {
        var connectionId = stream.ReadUInt32();
        var requestId = stream.ReadUInt32();
        var accountId = stream.ReadUInt32();
        var characters = accountId != 0
            ? CharacterManager.LoadCharacters(accountId)
            : [];
        Connection.SendPacket(new GLRequestInfoPacket(connectionId, requestId, characters));
    }
}
