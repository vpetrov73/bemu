﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BEmu.MarketDataRequest
{
    internal class MessageMarketSubscriptionStarted : Message
    {
        private readonly CorrelationID _correlationId;
        private readonly string _topicName;
        private readonly ElementMarketNull _exceptions;

        internal MessageMarketSubscriptionStarted(Subscription sub) : base(new Name("SubscriptionStarted"), sub.CorrelationID)
        {
            this._correlationId = sub.CorrelationID;
            this._topicName = sub.Security;
            this._exceptions = new ElementMarketNull("exceptions");
        }

        public override int NumElements { get { return 1; } }
        public override IEnumerable<Element> Elements { get { yield return this._exceptions; } }
        public override Element AsElement { get { return new ElementMarketSubscriptionStarted(this); } }

        public override string TopicName { get { return this._topicName; } }

        public override string ToString()
        {
            return string.Format("SubscriptionStarted = {{{0}}}{0}", Environment.NewLine);
        }
    }
}
