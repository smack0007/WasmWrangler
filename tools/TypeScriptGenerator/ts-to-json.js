// This node script is called from the TypeScriptGenerator program.
// Inspiration for this script taken from StackOverflow: https://stackoverflow.com/a/20197641/26566

const fs = require('fs');
const ts = require(__dirname + '/typescript.min');
const process = require('process');

const source = fs.readFileSync(process.argv[2], 'utf-8');

const sourceFile = ts.createSourceFile(process.argv[2], source, ts.ScriptTarget.Latest, true);

let nextId = 0;
function addId(node) {
    nextId++;
    node.id = nextId;
    ts.forEachChild(node, addId);
}
addId(sourceFile);

// No need to save the source again.
delete sourceFile.text;

const cache = [];
const json = JSON.stringify(sourceFile, (key, value) => {
  // Discard the following.
  if (key === 'flags' || key === 'transformFlags' || key === 'modifierFlagsCache') {
      return;
  }
  
  // Replace 'kind' with the string representation.
  if (key === 'kind') {
      value = ts.SyntaxKind[value];
  }
  if (typeof value === 'object' && value !== null) {
    // Duplicate reference found, discard key
    if (cache.includes(value)) return;

    cache.push(value);
  }
  return value;
});

console.info(json);
