using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace BullseyeDesktopApp.Models.DisplayObjects
{
    public class InventoryDisplay : INotifyPropertyChanged
    {
        public int ItemId { get; set; }
        public string? Description { get; set; }

        private int? quantity;
        public int? Quantity
        {
            get => quantity;
            set
            {
                if (quantity != value)
                {
                    quantity = value;
                    OnPropertyChanged(nameof(Quantity));
                }
            }
        }

        public int? MinimumThreshold { get; set; }
        public int OptimumThreshold { get; set; }

        private int? caseSize;
        public int? CaseSize
        {
            get => caseSize;
            set
            {
                if (caseSize != value)
                {
                    caseSize = value;
                    OnPropertyChanged(nameof(CaseSize));
                }
            }
        }

        private int? ordered;
        public int? Ordered
        {
            get => ordered;
            set
            {
                if (ordered != value)
                {
                    ordered = value;
                    OnPropertyChanged(nameof(Ordered));
                }
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged(string propertyName) =>
             PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
