fetch("/app/Common/Product/GetInfo1")
    .then((response) => {
        console.log(response.status);
        response.text().then((data) => {
            console.log(data)
        })
    }, (err) => {
        console.log(err)
    })