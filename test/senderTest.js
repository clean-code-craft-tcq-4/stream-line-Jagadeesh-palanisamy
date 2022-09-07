const {expect} = require('chai');
const sender = require('../sender');



describe('randomValueGenerator', () => {
    it('should exists', () => {
      expect(sender.randomValueGenerator).to.exist;
    });
    it('should return randomValue', () => {
        let list=sender.randomValueGenerator(0,10,5);
     expect(list.length).to.deep.equals(5);
    });
  });
