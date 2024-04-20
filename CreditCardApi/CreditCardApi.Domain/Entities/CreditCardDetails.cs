﻿
namespace CreditCardApi.Domain.Entities;

public class CreditCardDetails: Entity<CreditCardDetailsID>
{
    public CreditCardID CreditCarID { get; set; }
    public required CreditCardType CreditCardType { get; set; }
    public required double balance { get; set; }
    public required double Interest { get; set; }
    public double Currentbalance { get; set; }
    public double CurrentInterest { get; set; }
    public double MinimumFee { get; set; }
    public double MinimumFeePercent { get; set; }
    public virtual CreditCard CreditCard { get; set; }
    //ignore in sql
    public double CreditableInterest => Currentbalance * (Interest / 100);
    public double MinimumFeeToPay => Currentbalance * (MinimumFeePercent / 100);

    public CreditCardDetails(CreditCardID creditCarID, CreditCardType creditCardType, double balance, double interest, double currentbalance, double currentInterest)
    {
        CreditCarID = creditCarID;
        CreditCardType = creditCardType;
        this.balance = balance;
        Interest = interest;
        Currentbalance = currentbalance;
        CurrentInterest = currentInterest;
    }

}
