import { Injectable } from '@angular/core';
import { IHealthTips } from '../../../models/modelsInterface';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs/internal/Observable';

@Injectable({
  providedIn: 'root',
})
export class HealthTipsService {
  /*
  Tips: IHealthTips[] = [
    {
      id: 1,
      name: 'Sore Throat',
      tips: [
        {
          tipId: 1,
          tipName:
            'Avoid giving honey to children under one year old due to the risk of botulism.',
        },
        {
          tipId: 2,
          tipName: 'Use raw honey for maximum antibacterial benefits.',
        },
      ],
    },
    {
      id: 2,
      name: 'Digestion',
      tips: [
        {
          tipId: 3,
          tipName:
            'Drink ginger tea in moderation (1–2 cups daily) to avoid stomach irritation.',
        },
        {
          tipId: 4,
          tipName:
            'If you have acid reflux, consume ginger in small amounts, as excessive intake may worsen symptoms.',
        },
      ],
    },
    {
      id: 3,
      name: 'Inflammation',
      tips: [
        {
          tipId: 4,
          tipName:
            'Add a pinch of black pepper to enhance curcumin absorption.',
        },
        {
          tipId: 5,
          tipName:
            "If you're on blood thinners, consult a doctor before consuming turmeric regularly.",
        },
      ],
    },
    {
      id: 4,
      name: 'Skin Burns',
      tips: [
        {
          tipId: 6,
          tipName:
            'Always use fresh aloe vera or a pure gel without added chemicals.',
        },
        {
          tipId: 7,
          tipName:
            'Test on a small patch of skin first to check for allergic reactions.',
        },
      ],
    },

    {
      id: 5,
      name: 'Headaches',
      tips: [
        {
          tipId: 8,
          tipName:
            'Never apply peppermint oil directly to the skin without diluting it first.',
        },
        {
          tipId: 9,
          tipName:
            'Avoid using peppermint oil if you have asthma, as it may trigger breathing issues.',
        },
      ],
    },
  ];
  */
  private apiUrl = 'https://localhost:7218/api/HealthTips';
  constructor(private http: HttpClient) {}
  getHealthTips(): Observable<IHealthTips[]> {
    return this.http.get<IHealthTips[]>(`${this.apiUrl}`);
  }

  getHealthTipsByName(name: string): Observable<IHealthTips[]> {
    let params = new HttpParams().set('DiseaseName', name);
    return this.http.get<IHealthTips[]>(`${this.apiUrl}/search`, {
      params,
    });
  }
}
