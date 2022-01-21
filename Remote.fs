type ServiceInfo = {
Name : string
Endpoint: Uri
}
And then we can define an error type that builds on this:
type RemoteServiceError = {
Service : ServiceInfo
Exception : System.Exception
}



type InvoicePaymentResult =
| FullyPaid
| PartiallyPaid of ...
// domain workflow: pure function
let applyPayment unpaidInvoice payment :InvoicePaymentResult =



type PayInvoiceCommand = {
InvoiceId : ...
Payment : ...
}
// command handler at the edge of the bounded context
let payInvoice payInvoiceCommand =
// load from DB