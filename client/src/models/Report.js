import { DatabaseItem } from "./DatabaseItem.js";
import { Profile } from "./Profile.js";


export class Report extends DatabaseItem {
  constructor(data) {
    super(data);
    this.title = data.title;
    this.body = data.body;
    this.pictureOfDisgust = data.pictureOfDisgust;
    this.creatorId = data.creatorId;
    this.restaurantId = data.restaurantId;
    this.creator = new Profile(data.creator);
  }
}
