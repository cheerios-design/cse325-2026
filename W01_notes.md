# Week 01 — Build .NET Applications (friendly notes)

Hi! This repo contains the completed artifacts for the W01 assignment: a small Web API (ContosoPizza) with CRUD support and the files app changes that produce a sales summary.

What I added
- A web API project: `ContosoPizza` with a `Pizza` model, an in-memory `PizzaService`, and a `PizzaController` with GET/POST/PUT/DELETE.
- An HTTP test file: `ContosoPizza/ContosoPizza.http` (example requests and expected status codes).
- An updated files app: `mslearn-dotnet-files/Program.cs` includes a `GenerateSalesSummaryReport` function that writes `sales-summary.txt`.

Evidence (GET /pizza/ output including the required additional record)

```
[
  { "id": 1, "name": "Classic Italian", "isGlutenFree": false },
  { "id": 2, "name": "Veggie", "isGlutenFree": true },
  { "id": 3, "name": "Hawaiian", "isGlutenFree": false }
]
```

Sales summary function (text copy)

```
void GenerateSalesSummaryReport(Dictionary<string, decimal> totalsByFile, string outputPath)
{
    var sb = new StringBuilder();
    sb.AppendLine("Sales Summary");
    sb.AppendLine("----------------------------");

    var grandTotal = totalsByFile.Values.Sum();
    sb.AppendLine();
    sb.AppendLine($" Total Sales: {grandTotal:C}");
    sb.AppendLine();
    sb.AppendLine(" Details:");

    foreach (var kv in totalsByFile.OrderBy(k => k.Key))
    {
        var name = Path.GetFileName(kv.Key);
        sb.AppendLine($"  {name}: {kv.Value:C}");
    }

    File.WriteAllText(outputPath, sb.ToString());
}
```

How to run and verify

1. Run the web API:

```
cd ContosoPizza
dotnet run
```

Then use `ContosoPizza/ContosoPizza.http` or a tool like `curl`/Postman to test the endpoints. Examples (from the `.http` file):

- GET `/pizza/` → 200 OK (lists pizzas)
- POST `/pizza/` → 201 Created (creates a new pizza)
- PUT `/pizza/{id}` → 204 No Content (updates pizza)
- DELETE `/pizza/{id}` → 204 No Content (deletes pizza)

2. Run the files app to generate sales summary:

```
cd mslearn-dotnet-files
dotnet run
```

This will ensure sample `stores/201`–`stores/204` exist, compute totals, write `salestotals.json` for each store, a combined `totals.txt`, and `sales-summary.txt` under the `stores` folder.

If you'd like, I can also run the API and paste the actual HTTP responses (with status codes) into this notes file as captured evidence — would you like that? 

Thanks — happy to tweak wording or packaging for submission.
