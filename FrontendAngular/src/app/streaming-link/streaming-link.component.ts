import { Component, Input, OnInit } from '@angular/core';

@Component({
  selector: 'app-streaming-link',
  templateUrl: './streaming-link.component.html',
  styleUrls: ['./streaming-link.component.css']
})
export class StreamingLinkComponent implements OnInit {

  constructor() {
    this.streamColor();
   }

  ngOnInit(): void {
  }

@Input()
streamLink:string = "";

@Input()
titleName:string = "";

color:string = "";

goToLink(){
  window.open(this.streamLink);
}

streamColor(){console.log(this.titleName);
  switch (this.titleName) {
    case "Netflix":
      console.log("YEET");
      this.color = "bg-warning";
      break;
  
    default:
      break;
  }
}

}
