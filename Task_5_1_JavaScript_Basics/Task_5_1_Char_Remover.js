
function removeDuplicateLetters(phrase)
{
    let separator = [" ", "\t", "?", "!", ":", ";", ",", "."];
    let array = phrase.split('');
    let literals = {};
    let startLiteral = 0;
    let wordsArray = [];
    let result;

    function wordsPush(message, index)
    {
        if (!separator.indexOf(message))
        {
            wordsArray.push(phrase.substr(startLiteral, index - startLiteral));
            startLiteral = index + 1;
        }
    }

    array.forEach(wordsPush);
    wordsArray.push(phrase.substr(startLiteral));

    function wordsSplit(word)
    {
        function setIndex(message, i)
        {
            if (!literals[message] && -1 != word.indexOf(message, i + 1))
            {
                literals[message] = 1;
            }
        }

        word.split('').forEach(setIndex);
    }

    wordsArray.forEach(wordsSplit);

    function returnChar(repeatChar)
    {
        return !literals[repeatChar];
    }

    result = array.filter(returnChar).join('');
    return result;
}

console.log(removeDuplicateLetters("У попа была собака"));