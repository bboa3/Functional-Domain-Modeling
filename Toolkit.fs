/// Define the Result type
type Result<'Success,'Failure> =
| Ok of 'Success
| Error of 'Failure
/// Functions that work with Result
module Result =
let bind f aResult = ...
let map f aResult = ...


// type of functionAWithFruitError
Apple -> Result<Bananas,FruitError>



type PlaceOrderError =
| Validation of ValidationError
| Pricing of PricingError

// Adapted to return a PlaceOrderError
let validateOrderAdapted input =
input
|> validateOrder // the original function
|> Result.mapError PlaceOrderError.Validation
// Adapted to return a PlaceOrderError
let priceOrderAdapted input =
input
|> priceOrder // the original function
|> Result.mapError PlaceOrderError.Pricing

// When this is done, we can finally chain them together using bind:
let placeOrder unvalidatedOrder =
unvalidatedOrder
|> validateOrderAdapted // adapted version
|> Result.bind priceOrderAdapted // adapted version
