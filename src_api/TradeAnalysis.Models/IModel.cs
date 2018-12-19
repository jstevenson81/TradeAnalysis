using System;
using System.Collections.Generic;

namespace TradeAnalysis.Models
{
    public interface IModel: IDisposable
    {
        string Id { get; set; }
    }

    public abstract class ModelBase: IModel
    {
        #region shared properties

        private string _id;
        /// <summary>
        /// This is the identifier of the object.  It should always be a GUID
        /// </summary>
        public string Id
        {
            get
            {
                // if we have an id, return it
                if (!string.IsNullOrWhiteSpace(_id)) return _id;
                // if not, create it, set it and return it
                _id = CreateId();
                return _id;

            }
            set => _id = value;
        }

        public bool Active { get; set; }
        public bool InactiveTime { get; set; }

        #endregion

        #region methods
        protected string CreateId()
        {
            return Guid.NewGuid().ToString();
        }

        #endregion

        #region IDisposable members
        public void Dispose()
        {

        }
        #endregion

    }

    public class User : ModelBase
    {
        public string DisplayName { get; set; }
        public List<string> EmailAddresses { get; set; }

        public User()
        {
            EmailAddresses = new List<UserEmailAddress>();
        }

    }

    public class UserEmailAddress : ModelBase
    {
        public string UserId { get; set; }
        public string EmailAddress { get; set; }
        public bool Primary { get; set; }
        
    }

    public class Trade : ModelBase
    {
        public int ExchangeOrderId { get; set; }
        public string OrderId { get; set; }
        public string ExchangeTradeId { get; set; }
        public decimal Price { get; set; }
        public decimal Quantity { get; set; }
        public decimal Commission { get; set; }
        public DateTime Time { get; set; }
    }

    public class Order : ModelBase
    {
        public string UserId { get; set; }
        public int ExchangeOrderId { get; set; }
        public string Symbol { get; set; }
        public string Type { get; set; }
        public string Side { get; set; }
        public decimal OriginalQuantity { get; set; }
        public decimal ExecutedQuantity { get; set; }
        public DateTime Time { get; set; }
        public DateTime UpdateTime { get; set; }

        public List<Trade> Trades { get; set; }

        public Order()
        {
            Trades = new List<Trade>();
        }
    }

    public class ApiConfig : ModelBase
    {
        public string Key { get; set; }
        public string Secret { get; set; }
    }


}
