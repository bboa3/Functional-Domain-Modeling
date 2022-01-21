// bring in the types from the domain API module
open DomainApi
// ----------------------
// Order life cycle
// ----------------------
// validated state
type ValidatedOrderLine = ...
type ValidatedOrder = {
OrderId : OrderId
CustomerInfo : CustomerInfo
ShippingAddress : Address
BillingAddress : Address
OrderLines : ValidatedOrderLine list
}
and OrderId = Undefined
and CustomerInfo = ...
and Address = ...
// priced state
type PricedOrderLine = ...
type PricedOrder = ...
// all states combined
type Order =
| Unvalidated of UnvalidatedOrder
| Validated of ValidatedOrder
| Priced of PricedOrder
// etc


// ----------------------
// Definitions of Internal Steps
// ----------------------
// ----- Validate order -----
// services used by ValidateOrder
type CheckProductCodeExists =
ProductCode -> bool
type AddressValidationError = ...
type CheckedAddress = ...
type CheckAddressExists =
UnvalidatedAddress
-> AsyncResult<CheckedAddress,AddressValidationError>
type ValidateOrder =
CheckProductCodeExists // dependency
-> CheckAddressExists // dependency
-> UnvalidatedOrder // input
-> AsyncResult<ValidatedOrder,ValidationError list> // output
and ValidationError = ...
// ----- Price order -----
// services used by PriceOrder
type GetProductPrice =
ProductCode -> Price
type PricingError = ...
type PriceOrder =
GetProductPrice // dependency
-> ValidatedOrder // input
-> Result<PricedOrder,PricingError> // output
// etc