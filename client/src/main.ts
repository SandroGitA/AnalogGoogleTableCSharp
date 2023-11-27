//Берем главный div
let mainDiv = document.getElementsByClassName("mainDiv")
//Теперь создаем таблицу
let mainTable = document.createElement('table')
mainTable.style.borderCollapse = "collapse"

//URL, на который посылаются запросы
let url = "https://localhost:7136/api/v1/"

//Объявляем количество строк и столбцов
let row = 9;
let column = 9;

//Двумерный массив для отрисовки таблицы
let mainArray: number[][];

//Обходим циклом "массив" элементов
for (let i = 0; i < 9; i++) {
    //Создаем "строку"
    let tr = document.createElement('tr')
    tr.classList.add('row')

    for (let j = 0; j < 9; j++) {
        //Создаем "ячейку" таблицы
        let td = document.createElement('td')
        td.classList.add("cell")

        //div для нумерации строк и столбцов со стилями
        let divTr = document.createElement('div')
        divTr.classList.add("cell-row")

        //Массив букв для наименования столбцов
        let arrayChar = Array.from("ABCDEFGHIJKLM")

        //Если строка не первая и столбец первый,
        //создаем строку без input
        //и прописываем в ней букву(цифру) строки        
        if (i == 0 && j != 0) {
            divTr.innerText = arrayChar[j - 1]
            td.appendChild(divTr)
        }
        else if (i > 0 && j == 0) {
            divTr.innerText = i.toString()
            td.appendChild(divTr)
        }
        else {
            if (i == 0 && j == 0) {
                divTr.innerText = "f(x)"
                td.appendChild(divTr)
            }
            else {
                //Создаем поле ввода
                let input = document.createElement('input')
                input.type = "text"
                input.id = `${arrayChar[j - 1]}${i}`

                //Добавляем этот input в ячейку
                td.appendChild(input)
            }
        }

        //А потом уже ячейку в саму таблицу
        tr.appendChild(td)
    }

    //добавляем строку в саму таблицу
    mainTable.appendChild(tr)
}

//Добавляем таблицу в главный div
mainDiv[0].appendChild(mainTable)

//Ищем все input для events с помощью "всплытия"
let tableInputEvents = document.querySelector('table');
tableInputEvents?.addEventListener('keydown', (event) => {
    if (event.keyCode === 13) {
        const input = event.target as HTMLInputElement

        //const value = input.value;
        console.log(`cell_id=${input?.id}`)
        console.log(`data=${input?.value}`)

        //Собираем объект, для отправки данных на сервер
        let bodyRequest = JSON.stringify({
            id_cell: {
                id: input!.id
            },
            data: {
                text: input!.value
            }
        });

        //Формируем post запрос на сервер с данными
        let response = fetch(url, {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json;charset=utf-8'
            },
            body: bodyRequest
        });

        console.log(response)
    }
})

//Обработчик выделения ячейки, если в ней есть формула
tableInputEvents!.addEventListener('input', (event) => {
    //Получаем значение ячейки        
    let data = Array.from((event.target as HTMLInputElement)?.value)
    console.log(data)

    if (data[0] === '=') {
        console.log('Формула')
        //Если формула, то следующий симол должен начинаться с $,
        //и указание координаты ячейки, например B4, A1, C7
    }
})