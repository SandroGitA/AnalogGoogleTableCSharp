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

    for (j = 0; j < 9; j++) {
        //Создаем "ячейку" таблицы
        let td = document.createElement('td')
        td.classList.add("cell")

        //Div для нумерации строк и столбцов со стилями
        let divTr = document.createElement('div')
        divTr.classList.add("cell-row")

        //Если строка не первая и столбец первый,
        //создаем строку без инпутов
        //и прописываем в ней букву(цифру) строки
        if (i == 0) {            
            divTr.innerText = j            
            td.appendChild(divTr)
        }
        else if (i > 0 && j == 0) {            
            divTr.innerText = i            
            td.appendChild(divTr)
        }
        else {
            //Создаем поле ввода
            let input = document.createElement('input')

            //Добавляем это поле в ячейку
            td.appendChild(input)
        }

        //Определяем позицию каждой ячейки
        let position = `${i}${j}`
        td.id = position

        //А потом уже ячейку в саму таблицу
        tr.appendChild(td)
    }

    mainTable.appendChild(tr)
}

//Добавляем таблицу в главный div
mainDiv[0].appendChild(mainTable)