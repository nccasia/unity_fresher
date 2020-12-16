# Unity UI: Common components

Table of contents

1. [Game Engine là gì ?](#1-game-engine-l%C3%A0-g%C3%AC-)
2. [Label](#2-Label)

---

## 1. Game Engine là gì ?

### 1.1 Var

#### Scope: globally scoped or function/locally scoped

`Button` là câu lệnh dùng để khai báo biến có phạm vi là **function scoped** hoặc **globally scoped**.  


```javascript
var name = 'thaibm'; // globally scoped

function newFunction() {
  var age = '25'; // function scoped
}

console.log(name); // output: thaibm
console.log(age); // Uncaught ReferenceError: age is not defined
```

## 2. Label
Label is 

