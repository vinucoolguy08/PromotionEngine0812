using System;

namespace PromotionEngine
{
    public class Program
    {
        public static void Main(string[] args)
        {
            DiscountCalculator discountCalculator = new DiscountCalculator(new Discounts());
            Console.WriteLine(discountCalculator.CalculateTotal(1, 1, 1, null));
            Console.WriteLine(discountCalculator.CalculateTotal(5, 5, 1, null));
            Console.WriteLine(discountCalculator.CalculateTotal(3, 5, 1, 1));

            Console.ReadLine();
        }
    }

    public class Discounts : IDiscount
    {
       public  int ADiscount { get => 130; }
       public int BDiscount { get => 45; }
       public int CDDiscount { get => 30; }
    }

    public class DiscountCalculator 
    {
        public IDiscount _discount;
        public DiscountCalculator(IDiscount discount)
        {
            _discount = discount;
        }
        public int CalculateTotal(int? A, int? B, int? C, int? D)
        {
            int Total = 0;

            // Calculating for A Discount
            if (A >= 3)
            {
                Total = _discount.ADiscount;
                int AValue = A.Value - 3;
                if (AValue >= 3)
                {
                    for (int i = 1; i < AValue; i++)
                    {
                        Total += _discount.ADiscount;
                        AValue = AValue - 3;
                    }
                }
                if (AValue > 0 && AValue < 3)
                {
                    for (int i = 0; i < AValue; i++)
                    {
                        Total += 50;
                    }
                }
            }
            else if (A.HasValue)
            {
                for (int i = 0; i < A.Value; i++)
                {
                    Total += 50;
                }
            }

            //Calculating for B Discount
            if (B >= 2)
            {
                Total += _discount.BDiscount;
                int BValue = B.Value - 2;
                if (BValue >= 2)
                {
                    for (int i = 1; i < BValue; i++)
                    {
                        Total += _discount.BDiscount;
                        BValue = BValue - 2;
                    }
                }
                if (BValue > 0 && BValue < 2)
                {
                    for (int i = 0; i < BValue; i++)
                    {
                        Total += 30;
                    }
                }
            }
            else if (B.HasValue)
            {
                for (int i = 0; i < B.Value; i++)
                {
                    Total += 30;
                }
            }

            //Calculating for C and D Discount
            if (C.HasValue && D.HasValue)
            {
                Total += _discount.CDDiscount;
            }
            else if (C.HasValue)
            {
                Total += 20;
            }
            else if (D.HasValue)
            {
                Total += 15;
            }
            return Total;
        }
    }
}
