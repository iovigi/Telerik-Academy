

var cpuDb = [];
var id_inc_cpu = -1;

exports.listCpus = function () {
  return cpuDb;
};

exports.addCpu = function (cpu) {
  id_inc_cpu = id_inc_cpu + 1;
  cpu.id = id_inc_cpu;
  cpuDb[cpu.id] = cpu;
};


exports.getCpuById = function (id) {
  return cpuDb[id];
};

exports.deleteCpu = function (id) {
  cpuDb[id].remove();
};

exports.updateCpu = function (cpu) {
  cpuDb[cpu.id] = cpu;
}

var userDb = [];
var id_inc_user = 0;

exports.listUser = function () {
  return userDb;
};

exports.addUser = function (user) {
  id_inc_user = id_inc_user + 1;
  user.id = id_inc_user;
  userDb[user.id] = user;
};

exports.getUserById = function (id) {
  return userDb[id];
};

exports.getUserByUserName = function (username) {
  var user=undefined;
  console.log(userDb);

  for(var i=1;i<userDb.length;i++)
  {
      var u = userDb[i];
    console.log(u);
    console.log(username);
      if(u.username === username)
      {
          user = u;
          break;
      }
  }

  return user;
};

exports.deleteUser = function (id) {
  userDb[id].remove();
};

exports.updateUser = function (user) {
  userDb[user.id] = user;
}
