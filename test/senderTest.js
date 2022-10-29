const { expect } = require('chai');
const sender = require('../sender');

describe('randomValueGenerator', () => {
    let list = sender.randomValueGenerator(1, 10, 5);
    it('should exists', () => {
        expect(sender.randomValueGenerator).to.exist;
    });
    it('should return randomValue', () => {

        expect(list.length).to.deep.equals(5);
    });

    it('should return temperature Sensor exect value count', () => {
        expect(list.length).to.deep.equals(5);
    });

    it('should return temperature Sensor random value between the min and max value given', () => {
        let minValue = Math.min(...list);
        let maxValue = Math.max(...list);
        expect(minValue).to.be.above(0)
        expect(maxValue).to.be.below(10)
    });

});

describe('temperatureSensor', () => {
    it('should exists', () => {
        expect(sender.temperatureSensor).to.exist;
    });

});

describe('socSensor', () => {
    it('should exists', () => {
        expect(sender.socSensor).to.exist;
    });

});

describe('sensorStatistics', () => {
    it('should exists', () => {
        expect(sender.sensorStatistics).to.exist;
    });
});
