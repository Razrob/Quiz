using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Quiz
{
    public class CellsGenerator : SystemBase
    {
        [SerializeField] private CellPresenter _cellPresenter;
        [SerializeField] private Transform _parent;

        private Camera _camera;

        private const float boundsTreshold = 0.01f;

        protected override void Initialize()
        {
            GenerateCells();
        }

        private void GenerateCells()
        {
            _camera = Camera.main;

            LevelIterationData levelIterationData = commonData.SessionProcessData.CurrentLevelIterationData;
            VisualizationBundle visualizationBundle = commonData.SessionProcessData.CurrentVisualizationBundle;

            Vector2Int cellsPlacementMode = levelIterationData.CellsPlacementMode;
            CellsLayoutData cellsLayoutData = visualizationBundle.CellsLayoutData;

            float horizontalCenterOffcet = cellsPlacementMode.x % 2 != 0 ? 0f : -(cellsLayoutData.CellSize.x / 2f + cellsLayoutData.CellBorder);
            float verticalCenterOffcet = cellsPlacementMode.y % 2 != 0 ? 0f : -(cellsLayoutData.CellSize.y / 2f + cellsLayoutData.CellBorder);

            Vector2 bounds = Vector2.zero;
            bounds.x = cellsPlacementMode.x / 2 * (cellsLayoutData.CellSize.x + cellsLayoutData.CellBorder * 2f) + horizontalCenterOffcet;
            bounds.y = cellsPlacementMode.y / 2 * (cellsLayoutData.CellSize.y + cellsLayoutData.CellBorder * 2f) + verticalCenterOffcet;

            int cellIndex = 0;

            for (float y = -bounds.y; y <= bounds.y + boundsTreshold; y += cellsLayoutData.CellSize.y + cellsLayoutData.CellBorder * 2f)
            {
                for (float x = -bounds.x; x <= bounds.x + boundsTreshold; x += cellsLayoutData.CellSize.x + cellsLayoutData.CellBorder * 2f)
                {
                    CellPresenter cellPresenter = Instantiate(_cellPresenter, new Vector2(x + _camera.pixelWidth / 2, y + _camera.pixelHeight / 2),
                        Quaternion.identity, _parent);
                    cellPresenter.Background.color = visualizationBundle.BackgroundColors[Random.Range(0, visualizationBundle.BackgroundColors.Count)];

                    commonData.GridData.GetCell(cellIndex).AttachedCellPresenter = cellPresenter;
                    BundleCell bundleCell = commonData.GridData.GetCell(cellIndex).AttachedBundleCell;

                    if (bundleCell.Orientation == Orientation.Horizontal)
                        cellPresenter.Image.transform.Rotate(Vector3.forward * -90f);

                    cellPresenter.Image.sprite = bundleCell.CellSprite;

                    float aspectRation;

                    aspectRation = 1.0f * bundleCell.CellSprite.rect.width / bundleCell.CellSprite.rect.height;

                    float maxSpriteSize = Mathf.Max(cellsLayoutData.CellSize.x, cellsLayoutData.CellSize.y) * cellsLayoutData.ImageRelativeSize;

                    if (bundleCell.Orientation == Orientation.Horizontal)
                        maxSpriteSize *= cellsLayoutData.ImageRelativeSize;

                    Vector2 rectSize;

                    if (bundleCell.CellSprite.texture.width < bundleCell.CellSprite.texture.height)
                        rectSize = new Vector2(maxSpriteSize, maxSpriteSize / aspectRation);
                    else rectSize = new Vector2(maxSpriteSize * aspectRation, maxSpriteSize);

                    cellPresenter.Image.rectTransform.sizeDelta = rectSize;

                    cellIndex++;
                }
            }
        }
    }
}