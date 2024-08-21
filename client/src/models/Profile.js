import { DatabaseItem } from "./DatabaseItem.js";


export class Profile extends DatabaseItem {

  constructor(data) {
    super(data);
    this.name = data.name;
    this.picture = data.picture;
  }
}
