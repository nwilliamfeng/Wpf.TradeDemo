using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo
{
    public class Trade
    {
        public string  Code { get; set; }

         

        public string Name { get; set; }

        public ObservableCollection<TradeItem> Gvns { get; set; } = new ObservableCollection<TradeItem>();

        public ObservableCollection<TradeItem> Tkns { get; set; } = new ObservableCollection<TradeItem>();

    }


    public class TradeItem
    {
        public decimal DealPrice { get; set; }

        public bool IsGvn => Deals.Count > 0 ? Deals.FirstOrDefault().IsGVNDeal : false;

        public ObservableCollection<Deal> Deals { get; set; } = new ObservableCollection<Deal>();

        
          
    }


    public class Deal
    {
        public int DealCount { get; set; }

        public string Name { get; set; }

        public string OperatorA { get; set; }

        public string OperatorB { get; set; }

        public bool OffSetEnable { get; set; }

        public int OffSet { get; set; }

        public decimal DealPrice { get; set; }

        public bool IsGVNDeal { get; set; }

        public bool IsOperatorActive { get; set; }
    }
}
