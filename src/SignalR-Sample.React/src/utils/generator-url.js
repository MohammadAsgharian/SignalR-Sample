export function GenerateUrl(partialUrl, params) {
    let url = partialUrl;
    let postFix = "";
  
    if (!params) return url;
    Object.keys(params).forEach((key) => {
      if (params[key] === undefined) return;
      const searchKey = `{${key}}`;
      if (url.indexOf(searchKey) !== -1) {
        url = url.replace(searchKey, params[key]);
      } else {
        if (!postFix) {
          postFix = "?";
        } else {
          postFix += "&";
        }
        postFix += `${key}=${params[key]}`;
      }
    });
  
    return url + postFix;
  }
  