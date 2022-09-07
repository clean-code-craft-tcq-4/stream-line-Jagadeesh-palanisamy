const { expect } = require('chai');
const sender = require('../sender');

describe('randomValueGenerator', () => {
    it('should exists', () => {
        expect(sender.randomValueGenerator).to.exist;
    });
    it('should return randomValue', () => {
        let list = sender.randomValueGenerator(0, 10, 5);
        expect(list.length).to.deep.equals(5);
    });
});

describe('temperatureSensor', () => {
    let list = sender.temperatureSensor(0, 50, 10);
    it('should exists', () => {
        expect(sender.temperatureSensor).to.exist;
    });
    it('should return temperature Sensor exect value count', () => {
        expect(list.length).to.deep.equals(10);
    });
    it('should return temperature Sensor random value between the min and max value given', () => {
        let minValue = Math.min(...list);
        let maxValue = Math.max(...list);
        expect(minValue).to.be.above(0)
        expect(maxValue).to.be.below(50)
    });
});

describe('socSensor', () => {
    let list = sender.socSensor(10, 70, 20);
    it('should exists', () => {
        expect(sender.socSensor).to.exist;
    });
    it('should return soc Sensor exect value count', () => {
        expect(list.length).to.deep.equals(20);
    });
    it('should return soc Sensor random value between the min and max value given', () => {
        let minValue = Math.min(...list);
        let maxValue = Math.max(...list);
        expect(minValue).to.be.above(10)
        expect(maxValue).to.be.below(70)
    });
});

describe('sensorStatistics', () => {
    it('should exists', () => {
        expect(sender.sensorStatistics).to.exist;
    });
});
