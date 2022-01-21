// ----------------------
// Input data
// ----------------------
type UnvalidatedOrder = {
OrderId : string
CustomerInfo : UnvalidatedCustomer
ShippingAddress : UnvalidatedAddress
}
and UnvalidatedCustomer = {
Name : string
Email : string
}
and UnvalidatedAddress = ...
// ----------------------
// Input Command
// ----------------------
type Command<'data> = {
Data : 'data
Timestamp: DateTime
UserId: string
// etc
}

type PlaceOrderCommand = Command<UnvalidatedOrder>
And here are the outputs and the workflow definition itself:
// ----------------------
// Public API
// ----------------------
/// Success output of PlaceOrder workflow
type OrderPlaced = ...
type BillableOrderPlaced = ...
type OrderAcknowledgmentSent = ...
Chapter 7. Modeling Workflows as Pipelines • 138
report erratum • discuss
type PlaceOrderEvent =
| OrderPlaced of OrderPlaced
| BillableOrderPlaced of BillableOrderPlaced
| AcknowledgmentSent of OrderAcknowledgmentSent
/// Failure output of PlaceOrder workflow
type PlaceOrderError = ...
type PlaceOrderWorkflow =
PlaceOrderCommand // input command
-> AsyncResult<PlaceOrderEvent list,PlaceOrderError> // output events