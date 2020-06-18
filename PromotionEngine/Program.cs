using System;
using System.Collections;
using System.Xml.Schema;

namespace PromotionEngine
{
    class Program
    {
        static void Main(string[] args)
        {
             int promoType_3A = 130;
             int promoType_2B= 45;
             int promoType_CAndD= 30;

            int SKU_A_Cost = 50;
            int SKU_B_Cost = 30;
            int SKU_C_Cost = 20;
            int SKU_D_Cost = 15;

            Hashtable htCartOrder = new Hashtable();
        
            int SKU_A= 3;
            int SKU_B = 5;
            int SKU_C=1;
            int SKU_D = 1;

            int promoType_3A_Set_Count = SKU_A / 3;
            int promoType_3A_Remaining_Count = SKU_A % 3;

            int promoType_2B_Set_Count = SKU_B / 2;
            int promoType_2B_Remaining_Count = SKU_B % 2;
             
            int promoType_1C_Set_Count = SKU_C ;
            //int promoType_1C_Remaining_Count = SKU_C / 1;

            int promoType_1D_Set_Count = SKU_D;
            //int promoType_1D_Remaining_Count = SKU_D / 1;

            int TotalCost = int.MinValue;


            if ((SKU_C == 0 || SKU_D == 0) )
            {
                TotalCost = ((promoType_3A_Set_Count * promoType_3A) + promoType_3A_Remaining_Count * SKU_A_Cost) + ((promoType_2B_Set_Count * promoType_2B) + promoType_2B_Remaining_Count * SKU_B_Cost) + (SKU_C * SKU_C_Cost) + (SKU_D * SKU_D_Cost);
            }
            else
            {
                if (SKU_C == SKU_D)
                {
                    TotalCost = ((promoType_3A_Set_Count * promoType_3A) + promoType_3A_Remaining_Count * SKU_A_Cost) + ((promoType_2B_Set_Count * promoType_2B) + promoType_2B_Remaining_Count * SKU_B_Cost) + (promoType_CAndD * SKU_C);
                }
                else
                {
                    int common_SKU_C_Ans_D = SKU_C > SKU_D ? (SKU_C - SKU_D) : (SKU_D - SKU_C);
                    int remaining_SKU_C = (common_SKU_C_Ans_D > SKU_C) ? common_SKU_C_Ans_D - SKU_C : SKU_C - common_SKU_C_Ans_D;
                    int remaining_SKU_D = (common_SKU_C_Ans_D > SKU_D) ? common_SKU_C_Ans_D - SKU_D : SKU_D - common_SKU_C_Ans_D;

                    TotalCost = ((promoType_3A_Set_Count * promoType_3A) + promoType_3A_Remaining_Count * SKU_A_Cost) + ((promoType_2B_Set_Count * promoType_2B) + promoType_2B_Remaining_Count * SKU_B_Cost) + (common_SKU_C_Ans_D * promoType_CAndD) + (remaining_SKU_C * SKU_C_Cost) + (remaining_SKU_D * SKU_D_Cost);
                }

            }
            Console.WriteLine(TotalCost);
            Console.ReadKey();

        }
    }
}
