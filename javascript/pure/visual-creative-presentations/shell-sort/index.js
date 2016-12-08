const data = d3.range(60).reverse();

for (let i = data.length; i; i--) {
  let j = Math.floor(Math.random() * i);
  [data[i - 1], data[j]] = [data[j], data[i - 1]];
}

let gap = Math.floor(data.length / 2);
let testing = gap - 1;
let testingDown;
let highlight = [];

function iterate() {
  if (!testingDown) {
    testing++;    
  }
  
  if (testing >= data.length) {
    gap = Math.floor(gap / 2);
    
    if (gap === 0) {
      highlight = [];
      return;
    }
    
    testing = gap - 1;
    iterate();
    return;
  }
  
  const actualTest = testingDown || testing;
  
  highlight = [actualTest, actualTest - gap];
  
  if (data[actualTest] < data[actualTest - gap]) {
    [data[actualTest], data[actualTest - gap]] = [data[actualTest - gap], data[actualTest]];
    if (actualTest - gap - gap >= 0) {
      testingDown = actualTest - gap;
    }
  } else {
    testingDown = undefined; 
  }
}

const svg = d3.select('svg');
const width = svg.attr('width');
const height = svg.attr('height');

const xScale = d3.scaleBand()
  .domain(d3.range(data.length))
  .rangeRound([50, width - 5])
  .paddingInner(0.5);

const yScale = d3.scaleLinear()
  .domain(d3.extent(data))
  .range([30, height - 30]);

svg.selectAll('rect')
  .data(data, (d) => d)
  .enter()
    .append('rect')
    .attr('x', (d, i) => xScale(i))
    .attr('y', (d) => height - 10 - yScale(d))
    .attr('width', xScale.bandwidth())
    .attr('height', (d) => yScale(d));

setInterval(function () {
  iterate();

  svg.selectAll('rect')
    .data(data, (d) => d)
    .classed('active', (d, i) => highlight.includes(i))
    .classed('completed', (d, i) => highlight.length === 0)
    .transition()
    .duration(100)
    .attr('x', (d, i) => xScale(i));
}, 100);