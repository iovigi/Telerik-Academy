function solve() {
     var _generateNumberArray;
     var _countOfTry;
     var _countOfTry;
 
 
-  function init(playerName, endCallback) {
+    function init(playerName, endCallback) {
-      _playerName = playerName;
+        _playerName = playerName;
-      _endCallback = endCallback;
+        _endCallback = endCallback;
-      _generateNumberArray = [];
+        _generateNumberArray = [];
-      _countOfTry = 0;
+        _countOfTry = 0;
 
 
-      for (var i = 0; i < 4; i++) {
+        for (var i = 0; i < 4; i++) {
-          _generateNumberArray.push(Math.floor((Math.random() * 10) + 1));
+            _generateNumberArray.push(Math.floor((Math.random() * 10) + 1));
-      }
+        }
-  }
+    }
 
 
-  function guess(number) {
+    function guess(number) {
-      if (_playerName == undefined) {
+        if (_playerName == undefined) {
-          throw "not init";
+            throw "not init";
-      }
+        }
 
 
-      _countOfTry++;
+        _countOfTry++;
 
 
-      var sheeps = 0;
+        var sheeps = 0;
-      var rams = 0;
+        var rams = 0;
-      var i = 0;
+        var i = 0;
-      var j = 0;
+        var j = 0;
 
 
-      var stringNumber = number.toString();
+        var stringNumber = number.toString();
 
 
-      for (i = 0;  i < 4; i ++) {
+        for (i = 0; i < 4; i++) {
-          var digit = +stringNumber.charAt(i);
+            var digit = +stringNumber.charAt(i);
 
 
-          if (_generateNumberArray[i] == digit) {
+            if (_generateNumberArray[i] == digit) {
-              rams++;
+                rams++;
-              continue;
+                continue;
-          }
+            }
 
 
-          for (j = 0; j < 4; j ++) {
+            for (j = 0; j < 4; j++) {
-              if (_generateNumberArray[j] == digit) {
+                if (_generateNumberArray[j] == digit) {
-                  sheeps++;
+                    sheeps++;
-                  break;
+                    break;
-              }
+                }
-          }
+            }
-      }
+        }
 
 
-      if (rams == 4) {
+        if (rams == 4) {
-          _endCallback();
+            var highScore = JSON.parse(localStorage.getItem("highScore")) || new HighScore();
-      }
 
 
-      return { sheep: sheeps, rams: rams }
+            highScore.addPlayer(_playerName, _countOfTry);
-  }
 
 
-  function getHighScore(count) {
+            localStorage.setItem("highScore", JSON.stringify(highScore));
 
 
-  }
+            _endCallback();
+        }
 
 
-  return {
+        return { sheep: sheeps, rams: rams }
-    init, guess, getHighScore
+    }
-  }
+
+    function getHighScore(count) {
+        if (count <= 0) {
+            throw "count error";
+        }
+
+        var highScore = JSON.parse(localStorage.getItem("highScore")) || new HighScore();
+
+        $(highScore.players).slice(count);
+    }
+
+    var HighScore = function () {
+        this.players = [];
+    };
+
+    HighScore.prototype.addPlayer = function (name, score) {
+        var player = new Player(name, score);
+
+        this.players.push(player);
+
+        _.sortBy(this.players, "score");
+    }
+ 
+
+    var Player = function (name, score) {
+        this.name = name;
+        this.score = score;
+    };
+
+    return {
+        init, guess, getHighScore
+    }
}


module.exports = solve;
