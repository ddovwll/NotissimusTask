let mouseData = {coordinates: []};

document.addEventListener('mousemove', (event) => {
    const timestamp = new Date().toISOString();
    const x = event.clientX;
    const y = event.clientY;

    mouseData.coordinates.push({X: x, Y: y, T: timestamp});
});

document.getElementById('sendDataButton').addEventListener('click', () => {
    if (mouseData.length === 0) {
        alert("Нет данных для отправки.");
        return;
    }

    fetch('/', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(mouseData)
    })
        .then(response => {
            if (response.ok) {
                alert("Данные успешно отправлены!");
                mouseData = {coordinates: []};
            } else {
                alert("Произошла ошибка при отправке данных.");
            }
        })
        .catch(error => {
            alert("Произошла ошибка при отправке данных.");
        });
});
