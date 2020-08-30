
let storage = new Service();
let addMemo = document.querySelector(".addMemo");
let saving = document.querySelector(".saving");
let closing = document.querySelector(".closing");
let trashIcon = "<img src='img/trash.png'/>";

addMemo.onclick = function() {addMemoFunc()};
saving.onclick = function() {saveMemo()};
closing.onclick = function() {closeModal()};

function Memo(header = "", text = "") // to use the library
{
    return {
        header: header,
        text: text
    };
}

function addMemoFunc() // function of clicking on the plus
{
    document.querySelector(".saving").textContent = "Создать";
    let modal = document.getElementById("modalID");
    let id = document.getElementById("hiddenID");
    let header = document.getElementById("inHead");
    let text = document.getElementById("inText");
    id.value = "";
    header.value = "";
    text.value = "";
    modal.classList.add("selected");
    modal.classList.remove("modal");
}

function editMemoFunc(memo) // memo editing function
{
    document.querySelector(".saving").textContent = "Сохранить";
    let modal = document.getElementById("modalID");
    let id = document.getElementById("hiddenID");
    let header = document.getElementById("inHead");
    let text = document.getElementById("inText");
    id.value = memo.firstChild.value;
    header.value = memo.querySelector(".memoHeader").innerHTML;
    text.value = memo.querySelector(".memoText").innerHTML;
    modal.classList.add("selected");
    modal.classList.remove("modal");
}

function closeModal()
{
    let modal = document.getElementById("modalID");
    modal.classList.add("modal");
    modal.classList.remove("selected");
}

function showMemo(memo) // output to a web page
{
    let memoContainer = document.querySelector(".memoContainer");
    let divContainer = document.createElement("div");
    divContainer.classList.add("memo");
    divContainer.classList.add("selected");
    let memoId = document.createElement("input");
    memoId.classList.add("memoId");
    memoId.setAttribute("type", "hidden");
    memoId.setAttribute("value", memo.id);
    let header = document.createElement("div");
    header.classList.add("memoHeader");
    header.innerHTML = memo.header;
    let text = document.createElement("div");
    text.classList.add("memoText");
    text.innerHTML = memo.text;
    let trash = document.createElement("div");
    trash.classList.add("trash");
    trash.innerHTML = trashIcon;
    memoContainer.prepend(divContainer);
    divContainer.append(memoId, header, text, trash);
    divContainer.onclick = function() {editMemoFunc(divContainer)};
    trash.onclick = function() {deleteMemoFunc(divContainer)};
}

function saveMemo()
{
    let id = document.getElementById("hiddenID").value;
    let header = document.getElementById("inHead").value;
    let text = document.getElementById("inText").value;
    let memo = new Memo(header, text);
    
    if (id == "")
    {
        storage.add(memo);
    }
    else
    {
        let arrayMemoID = document.getElementsByClassName("memoId");
        for (let i = 0; i < arrayMemoID.length; i++)
        {
            if (arrayMemoID[i].value == id)
            {
                arrayMemoID[i].parentNode.remove();
            }
        }
        storage.updateById(id, memo);
    }
    
    closeModal();
    showMemo(memo);
}

function deleteMemoFunc(memo)
{
    event.stopPropagation();
    let confirmWindow = confirm("Confirm the deletion");
    if (confirmWindow)
    {
        let id = memo.value;
        storage.deleteById(id);
        memo.remove();
    }
}