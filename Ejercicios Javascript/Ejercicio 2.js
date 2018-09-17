function mul(first) {
  return function(second) {
    return function(third) {
      return first * second * third;
    }
  }
}

console.log('result: ' + mul(2)(3)(4));
console.log('result: ' + mul(4)(3)(4));
