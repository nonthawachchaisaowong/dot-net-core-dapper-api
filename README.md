
## Project overview

This project using dapper for CRUD.
These are api specs:
|Description|Verb|URL|
|----|----|----|
|Get all event|GET|GET https://localhost:44312/event/|
|Get specific evnt|GET|GET https://localhost:44312/event/{id}|
|Delete specific event|DELETE|DELETE https://localhost:44312/event/{id}|
|Update event|PUT|PUT https://localhost:44312/event/|

Example body for create event:

```json
{
	"EventName" : "Error"
}
```
