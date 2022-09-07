function randomValueGenerator(minThreshold = 0, maxThreshold = 50, range = 50) {
    let randomlist = []
    for (let i = 0; i < range; i++) {
        let lowLimit = Number(minThreshold);
        let highLimit = Number(maxThreshold);
        let randomNum = Math.floor(Math.random() * (highLimit - lowLimit) + lowLimit);
        randomlist.push(randomNum)
    }
    printStatement(randomlist);
    return randomlist
}

function temperatureSensor(minThreshold = 0, maxThreshold = 50, range = 50) {
    randomValueGenerator(minThreshold, maxThreshold, range);
}

function socSensor(minThreshold = 0, maxThreshold = 50, range = 50) {
    randomValueGenerator(minThreshold, maxThreshold, range);
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