# Simple Calculator

```csharp
SimpleCalculatorController simpleCalculatorController = client.SimpleCalculatorController;
```

## Class Name

`SimpleCalculatorController`


# Calculate

Calculates the expression using the specified operation.

```csharp
CalculateAsync(
    Models.OperationTypeEnum operation,
    double x,
    double y)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `operation` | [`OperationTypeEnum`](../../doc/models/operation-type-enum.md) | Template, Required | The operator to apply on the variables |
| `x` | `double` | Query, Required | The LHS value |
| `y` | `double` | Query, Required | The RHS value |

## Response Type

`Task<double>`

## Example Usage

```csharp
OperationTypeEnum operation = OperationTypeEnum.SUM;
double x = 222.14;
double y = 165.14;
try
{
    double result = await simpleCalculatorController.CalculateAsync(
        operation,
        x,
        y
    );
}
catch (ApiException e)
{
    // TODO: Handle exception here
    Console.WriteLine(e.Message);
}
```

