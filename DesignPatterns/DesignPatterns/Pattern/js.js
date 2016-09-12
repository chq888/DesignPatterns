
// object literal
// key-value
var employee = {
  "employeeId": 1,
  "name": "ccc",
  "display": function () {
    return this.name;
  }
};

var em = {};
em.employeeId = 1;
em.name = "cuong";
em.display = function () {
  return this.name;
};


// function objects
var employee2 = function () {
  this.employeeId = 1;
  this.name = "c";
  this.display = function () {
    return this.name; 
  };
}

var em2 = new employee2();


// function prototype
var employee3 = function (id, name) {
  // private property
  this._employeeId = id;
  this._name = name;
};

employee3.prototype.getName = function () {
  return this._name;
}
employee3.prototype.setName = function (n) {
  this._name = n;
}

employee3.prototype.display = function () {
  return this._name;
}

var emp3 = new employee3(1, "c");
emp3.setName("c");
emp3.getName();
emp3.display();

// intermediate invoke function expression
// not pollute global namespace with var and function that are needed only once
// preserve $ inside plugin code to avoid ...
(function ($) {
  $.fn.decorate = function (settings) {
    //
  };
})(jQuery);



// namespace
var cusApp = {};
cusApp.Search = {};
cusApp.Search.searchById = function (id, target) {

};



// module
var jsApp = {};
jsApp.module1 = (function () {
  return {
    hello: function () {
      return "world";
    }
  }
})();


// reveal module

var jsApp2 = {};
jsApp.module2 = (function () {
  // private variable
  var msg = "ee";
  // private function
  var sayHello = function () {
    alert('1');
  };

  return {
    hello: sayHello
  };
})();


// to avoid long namespace, use sandbox
(function (global) {
  var cApp = function (mudules, callback) {
    if (!(this instanceof cApp)) {
      return new cApp(modules, callback);
    }

    for (var i = 0; i < modules.length; i++) {
      // generate sandbox object containing api of all requested modules
      cApp.modules[modules[i]](this);
      //cApp.modules["search"](this);
    }
    callback(this);
  };

  cApp.modules = {};
  global.cApp = cApp;

})(this);

cApp.modules.hello = function (sandbox) {
  sandbox.alo = function () {

  };
};

cApp.modules.search = function (sandbox) {
  sandbox.searchById = function (id, target) {

  };

  sandbox.searchByName = function (name, target) {

  };
};

$(document).ready(function () {
  var searchField = $("#searchField").val();
  if (searchField) {
    cApp(['search', 'hello'], function(sandbox) {
      sandbox.searchById(1, "results");
      sandbox.alo();
    });
  }
});

// singleton 1
var settings = function () {
  var instance = this;
  this.theme = "o";

  // constructor
  settings = function () {
    return instance;
  };
};

// singleton 2
var settings2 = (function () {
  var instance;
  function createInstance() {
    var s = new Object();
    s.them = "c";
    return s;
  }

  return {
    getInstance: function () {
      if (!instance) {
        instance = createInstance();
      }

      return instance;
    }
  };

})();

// observer
function comment() {
  this.observers = [];
}

comment.prototype = {
  subscribe: function (fn) {
    this.observers.push(fn);
  },
  unsubscribe: function (fn) {
    this.observers = this.handlers.filter(function (item) {
      if (item !== fn) {
        return item;
      }
    });
  },
  broadcast: function (data) {
    this.observers.forEach(function (item) {
      // item is function, null indicate that no specific value for this is to be used
      item.call(null, data);
    });
  }
}

$(document).ready(function () {
  var subscribe1 = function (data) {
    $("#div1").html(data);
  };

  var subscribe2 = function (data) {
    $("#div1").html(data);
  };

  var comment = new comment();
  comment.subscribe(subscribe1);
  comment.subscribe(subscribe2);

  $("#text1").keyup(function () {
    comment.broadcast($("#text1").val());
  });

});
