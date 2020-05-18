async function fetchJson(url){
  const response = await fetch(url);
  
  const headers = response.headers;
  const data =  await response.json();
  return {
    data:data,
    headers: headers
  };
}

//const arry = [];
//const headers = await response.headers.forEach((header, index) => {
//  arry.push(header);
//  if(index +1 == headers.length){
//    return arry;
//  }
//});