//Берем главный div
let mainDiv = document.getElementsByClassName("mainDiv")
//Теперь создаем таблицу
let mainTable = document.createElement('table')
mainTable.style.borderCollapse = "collapse"

//Обходим циклом "массив" элементов
for (i = 0; i < 9; i++) {
    //Создаем "строку"
    let tr = document.createElement('tr')
    tr.classList.add('row')

    //Если "строка" первая, создаем строку без инпутов
    //и прописываем в ней букву(цифру) строки
    if (i != 0) {
        let div = document.createElement('div')
        div.innerText = i
        div.style.fontWeight = "bold"    
        //tr.appendChild(div)
    }

    for (j = 0; j < 9; j++) {
        //Создаем ячейку таблицы
        let td = document.createElement('td')
        td.classList.add("cell")

        //Если "столбец" первый, создаем строку без инпутов
        //и прописываем в ней букву(цифру) столбца
        if (j != 0) {
            let div = document.createElement('div')
            div.innerText = j
            div.style.fontWeight = "bold"
            //tr.appendChild(div)
        }

        //Создаем поле ввода
        let input = document.createElement('input')                

        //Добавляем это поле в ячейку
        td.appendChild(input)
        //А потом уже ячейку в саму таблицу
        tr.appendChild(td)
    }

    mainTable.appendChild(tr)
}

//Добавляем таблицу в главный div
mainDiv[0].appendChild(mainTable)