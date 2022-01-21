# Type Function
```
Type input
type output
```

# Type Workflow

```
Type input
    UnvalidatedOrder

    type OrderTakingCommand =
    | Place of PlaceOrder
    | Change of ChangeOrder
    | Cancel of CancelOrder


Type output

    type PlaceOrderEvents = {
        AcknowledgmentSent : AcknowledgmentSent
        OrderPlaced : OrderPlaced
        BillableOrderPlaced : BillableOrderPlaced
    }

    type ValidateOrder =
        UnvalidatedOrder -> Result<ValidatedOrder,ValidationError list>

```


# Business Rules - Email Address

```
type CustomerEmail =
| Unverified of EmailAddress
| Verified of VerifiedEmailAddress // different from normal EmailAddress

type SendPasswordResetEmail = VerifiedEmailAddress -> ...
```

