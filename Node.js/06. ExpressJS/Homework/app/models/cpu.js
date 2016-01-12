// Example model


function CPU (opts) {
  if(!opts) opts = {};
  this.id= opts.id || 0;
  this.cpu = opts.cpu || '';
  this.model = opts.model || '';
  this.desc = opts.desc || '';
  this.imgLink = opts.imgLink || '';
}

module.exports = CPU;

