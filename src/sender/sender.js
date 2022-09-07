function randomValueGenerator(min_threshold = 0, max_threshold = 50, range = 50) {
    let randomlist = []
    for (let i = 0; i < range; i++) {
        lowLimit = Number(min_threshold);
        highLimit = Number(max_threshold);
        let randomNum = Math.floor(Math.random() * (highLimit - lowLimit) + lowLimit);
        randomlist.push(randomNum)
    }
    printStatement(randomlist);
    return randomlist
}

function temperatureSensor(min_threshold = 0, max_threshold = 50, range = 50) {
    randomValueGenerator(min_threshold, max_threshold, range);
}

function socSensor(min_threshold = 0, max_threshold = 50, range = 50) {
    randomValueGenerator(min_threshold, max_threshold, range);
}

function sensorStatistics(temMin, tempMax, socMin, socMax, tempRange, socRange) {
    temperatureSensor(temMin, tempMax, tempRange);
    socSensor(socMin, socMax, socRange);
}

function printStatement(statement) {
    console.log(statement);
}

// sensorStatistics(0,10,0,10,5,5);

module.exports = {
    randomValueGenerator,
    temperatureSensor,
    socSensor,
    sensorStatistics
};