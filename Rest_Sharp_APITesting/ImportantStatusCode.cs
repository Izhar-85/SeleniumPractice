using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rest_Sharp_APITesting
{
    internal class ImportantStatusCode
    {
    }
}
/*
 * 2xx: Successful Responses
     200 OK: The request was successful, and the server returned the requested resource. This is the most common status code for successful GET, PUT, or DELETE requests.
     201 Created: The request was successful, and the server created a new resource as a result. Commonly used for POST requests that create resources.
     204 No Content: The request was successful, but the server has no content to return. Often used in response to successful DELETE requests.

 *3xx: Redirection Messages
    301 Moved Permanently: The resource has been moved to a new URL permanently. Clients should update their links to the new URL.
    302 Found: The resource is temporarily under a different URL, but the client should continue using the original URL for future requests.
    304 Not Modified: Indicates that the resource has not been modified since the last request. The client can use the cached version of the resource.

 *4xx: Client Error Responses
   400 Bad Request: The server cannot process the request due to client-side errors (e.g., malformed request syntax, invalid request message framing).
   401 Unauthorized: The client must authenticate itself to get the requested resource. This status code is commonly used for missing or invalid authentication credentials.
   403 Forbidden: The client does not have access rights to the content, so the server is refusing to give the requested resource. Authentication will not help; the client is simply not allowed to access the resource.
   404 Not Found: The server cannot find the requested resource. This is the most common error when a resource is not available or the URL is incorrect.
   405 Method Not Allowed: The HTTP method used in the request is not allowed for the requested resource.
   409 Conflict: The request could not be processed because of a conflict in the current state of the resource, such as an edit conflict or version mismatch.
   422 Unprocessable Entity: The request was well-formed but was unable to be followed due to semantic errors, often used in RESTful APIs when validation fails.

 *5xx: Server Error Responses
  500 Internal Server Error: The server encountered an unexpected condition that prevented it from fulfilling the request. This is a generic error message for when no more specific message is suitable.
  501 Not Implemented: The server does not support the functionality required to fulfill the request. This status code is often returned when the server does not recognize the request method.
  502 Bad Gateway: The server, while acting as a gateway or proxy, received an invalid response from the upstream server.
  503 Service Unavailable: The server is not ready to handle the request, usually due to being temporarily overloaded or down for maintenance.
  504 Gateway Timeout: The server, while acting as a gateway or proxy, did not receive a timely response from the upstream server.
 */