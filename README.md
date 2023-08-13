# API Spec

## Get list of Movie
Request :
- Method : GET
- Endpoint : `/api/Movies`

Response :

```json
{
	"status" : boolean,
	"message" : string,
	"data" : [
		{
			"id" : integer,
			"title" : "string",
			"description" : "string",
			"rating" : "decimal",
			"image" : "string",
			"created_at" : "Datetime",
			"updated_at" : "Datetime"			
		},
		{
			"id" : integer,
			"title" : "string",
			"description" : "string",
			"rating" : decimal,
			"image" : "string",
			"created_at" : "Datetime",
			"updated_at" : "Datetime"			
		}
	]
}
```

## Get Movie by Id
Request :
- Method : GET
- Endpoint : `/api/Movies/:Id`

Response :

```json
{
	"status" : boolean,
	"message" : string,
	"data" : {
		"id" : integer,
		"title" : "string",
		"description" : "string",
		"rating" : decimal,
		"image" : "string",
		"created_at" : "Datetime",
		"updated_at" : "Datetime"			
	}	
}
```

## Add New Movie
Request :
- Method : POST
- Endpoint : `/api/Movies`
- Header :
    - Content-Type : application-json
- Body :
```json 
{
    "title" : "string",
	"description" : "string",
	"rating" : decimal,
	"image" : "string",
}
```

Response :

```json
{
	"status" : boolean,
	"message" : string,
	"data" : {
		"id" : integer,
		"title" : "string",
		"description" : "string",
		"rating" : decimal,
		"image" : "string",
		"created_at" : "Datetime",
		"updated_at" : null		
	}	
}
```

## Update Movie
Request :
- Method : PATCH
- Endpoint : `/api/Movies/:Id`
- Header :
    - Content-Type : application-json
- Body :
```json 
{
    "title" : "string",
	"description" : "string",
	"rating" : decimal,
	"image" : "string",
}
```

Response :

```json
{
	"status" : boolean,
	"message" : string,
	"data" : {
		"id" : integer,
		"title" : "string",
		"description" : "string",
		"rating" : decimal,
		"image" : "string",
		"created_at" : "Datetime",
		"updated_at" : "Datetime"			
	}
}
```

## Delete Movie
Request :
- Method : DELETE
- Endpoint : `/api/Movies/:Id`

Response :

```json
{
	"status" : boolean,
	"message" : string,
	"data" : null
}
```