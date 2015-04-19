﻿using WowPacketParser.Enums;
using WowPacketParser.Misc;
using WowPacketParser.Parsing;
using WowPacketParser.Store;
using WowPacketParser.Store.Objects;

namespace WowPacketParserModule.V6_0_2_19033.Parsers
{
    public static class TokenHandler
    {
        [Parser(Opcode.CMSG_BUY_WOW_TOKEN_START)]
        public static void HandleTokenBuyToken(Packet packet)
        {
            packet.ReadUInt32("UnkInt32");
            packet.ReadPackedGuid128("Buyer");
            packet.ReadUInt64("CurrentMarketPrice");
        }

        [Parser(Opcode.CMSG_BUY_WOW_TOKEN_CONFIRM)]
        public static void HandleTokenConfirmBuyToken(Packet packet)
        {
            packet.ReadUInt32("UnkInt32");
            packet.ReadUInt32("PendingBuyConfirmations");
            packet.ReadUInt64("GuaranteedPrice");
            packet.ReadBit("Confirmed");
        }

        [Parser(Opcode.CMSG_SELL_WOW_TOKEN_CONFIRM)]
        public static void HandleTokenConfirmSellToken(Packet packet)
        {
            packet.ReadPackedGuid128("TokenGuid");
            packet.ReadUInt32("UnkInt32");
            packet.ReadUInt32("PendingBuyConfirmations");
            packet.ReadUInt64("GuaranteedPrice");
            packet.ReadBit("Confirmed");
        }

        [Parser(Opcode.CMSG_SELL_WOW_TOKEN_START)]
        public static void HandleTokenSellToken(Packet packet)
        {
            packet.ReadUInt64("UnkInt64");
            packet.ReadUInt64("CurrentMarketPrice");
            packet.ReadUInt32("UnkInt32");
        }

        [Parser(Opcode.CMSG_REDEEM_WOW_TOKEN_CONFIRM)]
        public static void HandleConirmRedeemToken(Packet packet)
        {
            packet.ReadUInt32("UnkInt32");
            packet.ReadUInt64("Count");
            packet.ReadPackedGuid128("TokenGuid");
            packet.ReadUInt32("UnkInt32");
            packet.ReadBit("Confirm");
        }

        [Parser(Opcode.CMSG_REDEEM_WOW_TOKEN_START)]
        public static void HandleRedeemToken(Packet packet)
        {
            packet.ReadUInt64("Count");
            packet.ReadUInt32("UnkInt32");
            packet.ReadUInt32("UnkInt32");
        }

        [Parser(Opcode.CMSG_REQUEST_WOW_TOKEN_MARKET_PRICE)]
        public static void HandleTokenUpdateMarketPrice(Packet packet)
        {
            packet.ReadUInt32("UnkInt32");
        }

        [Parser(Opcode.SMSG_REQUEST_WOW_TOKEN_MARKET_PRICE_RESPONSE)]
        public static void HandleTokenUpdateMarketPriceResponse(Packet packet)
        {
            packet.ReadUInt64("CurrentMarketPrice");
            packet.ReadUInt32("UnkInt");
            packet.ReadUInt32("Result");
            packet.ReadUInt32("UnkInt2");
        }

        [Parser(Opcode.CMSG_UPDATE_WOW_TOKEN_COUNT)]
        public static void HandleTokenUpdateTokenCount(Packet packet)
        {
            packet.ReadUInt32("UnkInt32");
        }

        [Parser(Opcode.CMSG_GET_REMAINING_GAME_TIME)]
        public static void HandleGetRemainingGameTime(Packet packet)
        {
            packet.ReadUInt32("UnkInt32");
        }

        [Parser(Opcode.SMSG_TOKEN_UNK1)]
        public static void HandleTokenUnk1(Packet packet)
        {
            var count1 = packet.ReadInt32("UnkCount1");
            var count2 = packet.ReadInt32("UnkCount2");

            for (int i = 0; i < count1; i++)
                packet.ReadInt64("UnkInt64_1", i);

            for (int i = 0; i < count2; i++)
                packet.ReadInt64("UnkInt64_2", i);
        }

        [Parser(Opcode.CMSG_UPDATE_WOW_TOKEN_AUCTIONABLE_LIST)]
        public static void HandleUpdateListedAuctionableTokens(Packet packet)
        {
            packet.ReadUInt32("UnkInt");
        }

        [Parser(Opcode.SMSG_UPDATE_WOW_TOKEN_AUCTIONABLE_LIST_RESPONSE)]
        public static void HandleUpdateListedAuctionableTokensResponse(Packet packet)
        {
            packet.ReadInt32("UnkInt"); // send CMSG_UPDATE_WOW_TOKEN_AUCTIONABLE_LIST
            packet.ReadUInt32("Result");
            var count = packet.ReadUInt32("TokenCount");
            for (var i = 0; i < count; i++)
            {
                packet.ReadUInt64("UnkInt1", i);
                packet.ReadUInt32("UnkInt2", i);
                packet.ReadUInt32("Owner", i);
                packet.ReadUInt64("BuyoutPrice", i);
                packet.ReadUInt32("EndTime", i);
            }
        }
    }
}
