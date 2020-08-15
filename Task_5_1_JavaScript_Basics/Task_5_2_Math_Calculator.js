
function CalculateString(stringValue)
{
    let result = 0;
    let numbersArray = [];
    let converter = /\-?\d+(\.\d+)?|[\+,\-,\*,\/,\=]{1}/ig;
    numbersArray = stringValue.match(converter);

    if (numbersArray[0] !== NaN)
    {
        result += Number(numbersArray[0]);
    }

    for (let i = 0; i < numbersArray.length; i++)
    {
        switch (numbersArray[i])
        {
            case "+": result += Number(numbersArray[i + 1]);
                break;
            case "-": result -= Number(numbersArray[i + 1]);
                break;
            case "*": result *= Number(numbersArray[i + 1]);
                break;
            case "/": result /= Number(numbersArray[i + 1]);
                break;
            case "=":
                break;
            default:
                break;
        }
    }

    return result.toFixed(2);
}

let someString1 = "7.5 + 8.9/10 * 12 - 19 =";
console.log(someString1 + " " + (CalculateString(someString1)));

let someString2 = "8+8 * 3.000 =";
console.log(someString2 + " " + CalculateString(someString2));

let someString3 = "2 + 1 - 1 - 2 + 0.0 =";
console.log(someString3 + " " + CalculateString(someString3));

let someString4 = "2- 2 + 78 =";
console.log(someString4 + " " + CalculateString(someString4));