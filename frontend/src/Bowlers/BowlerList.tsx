import { useEffect, useState } from "react";
import { Bowlers } from "../types/Bowlers";
function BowlerList() {
  const [bowlerData, setBowlerData] = useState<Bowlers[]>([]);
  useEffect(() => {
    const fetchBowlerData = async () => {
      const rsp = await fetch("http://localhost:5231/BowlingLeague");
      const b = await rsp.json();
      setBowlerData(b);
    };
    fetchBowlerData();
  }, []);

  return (
    <>
      <table className="table table-bordered">
        <thead>
          <tr>
            <th>Bowler Name</th>
            <th>Team Name</th>
            <th>Address</th>
            <th>City</th>
            <th>State</th>
            <th>Zip</th>
            <th>Phone Number</th>
          </tr>
        </thead>
        <tbody>
          {bowlerData.map(
            (f) =>
              (f.teamName === "Marlins" || f.teamName === "Sharks") && (
                <tr key={f.bowlerId}>
                  <td>
                    {f.bowlerFirstName}{" "}
                    {f.bowlerMiddleInit && ` ${f.bowlerMiddleInit}`}{" "}
                    {/*Checks if the middle initial is blank*/}
                    {f.bowlerLastName}
                  </td>
                  <td>{f.teamName}</td>
                  <td>{f.bowlerAddress}</td>
                  <td>{f.bowlerCity}</td>
                  <td>{f.bowlerState}</td>
                  <td>{f.bowlerZip}</td>
                  <td>{f.bowlerPhoneNumber}</td>
                </tr>
              ),
          )}
        </tbody>
      </table>
    </>
  );
}
export default BowlerList;
