app.controller('controller', function ($scope) {

    $scope.styles = {
        tigerContainer: {
            'background-color': 'lightgrey',
            'width': '400px',
            'margin': '50px auto',
            'padding': '20px',
            'border-radius': '10px'
        },
        tigerInformationBox: {
            'display': 'inline-block',
            'vertical-align': 'top',
            'width': '48%'
        },
        tigerImg: {
            'width': '100%'
        },
        tigerHeader: {
            'text-align': 'center',
            'text-transform': 'uppercase',
            'margin': '0',
            'margin-bottom': '20px'
        }
    };
    $scope.tiger = {
        name: 'Pesho',
        born: 'Asia',
        birthDate: '2006',
        live: 'Sofia Zoo',
        image: 'http://tigerday.org/wp-content/uploads/2013/04/tiger.jpg'
    };
});